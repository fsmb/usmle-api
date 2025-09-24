/*
 * Copyright © Federation of State Medical Boards
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
 * documentation files (the “Software”), to deal in the Software without restriction, including without limitation the
 * rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit
 * persons to whom the Software is furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
 * WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
 * COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, 
 * ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */
using Fsmb.Api.Usmle.Client;
using Fsmb.Api.Usmle.Client.Models;

namespace Fsmb.Api.Usmle.Sample;

internal class Program
{
    public static void Main ( string[] args )
    {        
        var program = new Program();

        program.Run(args);        
    }

    #region API Calls
        
    //This method is for setting up a client for NET Framework or when not using dependency injection
    private UsmleApiClient CreateClient ( ProgramOptions options )
    {
        var clientOptions = new UsmleApiClientOptions() {
            Board = options.Board
        };

        var credentials = new UsmleApiClientCredentials() {
            ClientId = options.ClientId,
            ClientSecret = options.ClientSecret            
        };

        if (options.EnableNewTranscripts)
            credentials.RequestNewTranscriptsPermission();

        //HttpClient requires that base addresses end with a slash
        var httpClient = new HttpClient() {
            BaseAddress = new Uri(options.Url.EnsureEndsWith("/"))
        };

        return new UsmleApiClient(httpClient, clientOptions, credentials);
    }

    // Get summary of transcripts
    private async Task GetAvailableTranscriptsAsync ( UsmleApiClient client, TranscriptSummaryRequest request, CancellationToken cancellationToken )
    {
        //Call API
        Terminal.WriteDebug($"Getting summary of transcripts between {request.FromDate:d} and {request.ToDate:d}");
        var data = await client.GetAvailableTranscriptsSummaryAsync(request, cancellationToken).ConfigureAwait(false);
        if (!(data?.Items?.Any() ?? false))
        {
            Terminal.WriteWarning("No data found");
            return;
        }
        
        Terminal.WriteObject("Results", data);
    }

    // Get current transcript for a specific USMLE ID
    private async Task GetCurrentTranscriptAsync ( UsmleApiClient client, string usmleId, CancellationToken cancellationToken )
    {
        //Call API
        Terminal.WriteDebug($"Getting current transcript for USMLE ID {usmleId}");
        var data = await client.GetCurrentTranscriptAsync(usmleId, cancellationToken).ConfigureAwait(false);
        if (data == null)
            Terminal.WriteWarning("No data found");
        else
            Terminal.WriteObject("Transcript", data);
    }

    // Get USMLE transcript file for a specific USMLE ID
    private async Task GetUsmleTranscriptFileAsync ( UsmleApiClient client, string usmleId, string targetFile, CancellationToken cancellationToken )
    {        
        //Call API
        Terminal.WriteDebug($"Getting USMLE transcript file for USMLE ID {usmleId}");
        var data = await client.GetUsmleTranscriptFileAsync(usmleId, cancellationToken).ConfigureAwait(false);
        if (data?.Length == 0)
            Terminal.WriteWarning("No data found");
        else
        {            
            await File.WriteAllBytesAsync(targetFile, data, cancellationToken).ConfigureAwait(false);

            Terminal.Write($"{data.Length} bytes saved to '{targetFile}'");
        }        
    }

    // Requests a new transcript
    private async Task RequestNewTranscriptAsync ( UsmleApiClient client, string usmleId, CancellationToken cancellationToken )
    {
        //Call API
        Terminal.WriteDebug($"Requestings a new transcript for USMLE ID {usmleId}");
        
        await client.RequestNewTranscriptAsync(usmleId, cancellationToken).ConfigureAwait(false);        
    }
    #endregion

    #region Private Members        

    private Func<UsmleApiClient, Task> DisplayMenu ()
    {
        Terminal.WriteLine("USMLE API Options");
        Terminal.WriteLine("".PadLeft(20, '-'));

        Terminal.WriteLine("1) Get the current transcript for a specific USMLE ID");
        Terminal.WriteLine("2) Get the USMLE transcript file for a specific USMLE ID");
        Terminal.WriteLine("3) Get a summary of transcripts");

        if (_options.EnableNewTranscripts)
            Terminal.WriteLine("4) Request a new transcript (must have been granted the appropriate permissions)");

        Terminal.WriteLine("0) Quit");

        do
        {
            switch (Terminal.ReadKey(true).KeyChar)
            {
                case '0': return OnQuitAsync;
                case '1': return OnGetCurrentTranscriptAsync;
                case '2': return OnGetUsmleTranscriptFileAsync;
                case '3': return OnGetAvailableTranscriptsAsync;
                case '4':
                {
                    if (_options.EnableNewTranscripts)
                        return OnRequestNewTranscriptAsync;
                    break;
                }
            };
        } while (true);
    }

    private bool Initialize ( string[] args )
    {
        var options = ParseCommandLine(args);
        if (options == null)
        {
            ShowHelp();
            return false;
        };

        //Override defaults
        if (String.IsNullOrEmpty(options.Url))
        {
            var url = Terminal.ReadString($"URL? (press ENTER to use default of {ProgramOptions.DefaultUrl}) ", allowEmptyStrings: true);
            options.Url = String.IsNullOrEmpty(url) ? ProgramOptions.DefaultUrl : url;
        };

        if (String.IsNullOrEmpty(options.Board))
        {
            var board = Terminal.ReadString($"Board? (press ENTER to use default of {ProgramOptions.DefaultBoard}) ", allowEmptyStrings: true);
            options.Board = String.IsNullOrEmpty(board) ? ProgramOptions.DefaultBoard : board;
        };

        //Verify required values are set            
        if (String.IsNullOrEmpty(options.ClientId))
            options.ClientId = Terminal.ReadString("Client Id? ", allowEmptyStrings: false);

        if (String.IsNullOrEmpty(options.ClientSecret))
            options.ClientSecret = Terminal.ReadString("Client Secret? ", allowEmptyStrings: false);
        
        _options = options;

        //Create the client
        _client = CreateClient(_options);

        return true;
    }

    private Task OnQuitAsync ( UsmleApiClient client )
    {
        _quit = true;

        return Task.CompletedTask;
    }

    private async Task OnGetAvailableTranscriptsAsync ( UsmleApiClient client )
    {
        try
        {
            var fromDate = Terminal.ReadDate("From date (YYYY-MM-DD) (or ENTER to cancel)? ", allowEmpty: true);
            if (!fromDate.HasValue)
                return;

            var toDate = Terminal.ReadDate("To date (YYYY-MM-DD) (or ENTER to cancel)? ", minDate: fromDate, allowEmpty: true);
            if (!toDate.HasValue)
                return;

            var orderBy = Terminal.ReadString("Order by (ENTER to use default of `sentDate`)?", allowEmptyStrings: true);

            var limit = Terminal.ReadInt32("Limit (ENTER to use default of 100)? ", minValue: 0, allowEmpty: true);            
            var offset = Terminal.ReadInt32("OFfset (ENTER to use default of 0)? ", minValue: 0, allowEmpty: true);

            var request = new TranscriptSummaryRequest() {
                FromDate = fromDate.Value,
                ToDate = toDate.Value,
                OrderBy = orderBy
            };

            if (limit > 0)
                request.Limit = limit;
            if (offset > 0)
                request.Offset = offset;

            await GetAvailableTranscriptsAsync(client, request, CancellationToken.None).ConfigureAwait(false);
        } catch (Exception e)
        {
            e = e.Unwrap();

            Terminal.WriteError(e.Message);
        }
    }

    private async Task OnGetCurrentTranscriptAsync ( UsmleApiClient client )
    {
        try
        {
            //Get the USMLE ID
            var usmleId = Terminal.ReadUsmleId("USMLE ID? ");            

            await GetCurrentTranscriptAsync(client, usmleId, CancellationToken.None).ConfigureAwait(false);
        } catch (Exception e)
        {
            e = e.Unwrap();

            Terminal.WriteError(e.Message);
        }
    }

    private async Task OnGetUsmleTranscriptFileAsync ( UsmleApiClient client )
    {
        try
        {
            //Get the USMLE ID
            var usmleId = Terminal.ReadUsmleId("USMLE ID? ");
            
            var targetFile = Terminal.ReadString("Enter file name to save to? ");            
            targetFile = Path.GetFullPath(targetFile);

            await GetUsmleTranscriptFileAsync(client, usmleId, targetFile, CancellationToken.None).ConfigureAwait(false);
        } catch (Exception e)
        {
            e = e.Unwrap();

            Terminal.WriteError(e.Message);
        }
    }

    private async Task OnRequestNewTranscriptAsync ( UsmleApiClient client )
    {
        try
        {
            //Get the USMLE ID
            var usmleId = Terminal.ReadUsmleId("USMLE ID? ");

            await RequestNewTranscriptAsync(client, usmleId, CancellationToken.None).ConfigureAwait(false);
        } catch (Exception e)
        {
            e = e.Unwrap();

            Terminal.WriteError(e.Message);
        }
    }

    private ProgramOptions ParseCommandLine ( string[] args )
    {
        var options = new ProgramOptions();

        Action<string> argumentAction = null;
        foreach (var arg in args)
        {
            var isSwitch = arg.StartsWithAny('-', '/');
            var argument = (isSwitch ? arg.Trim('-', '/').ToLower() : arg).Trim();

            var badArgument = false;

            if (isSwitch)
            {
                switch (argument)
                {
                    case "clientid": argumentAction = value => options.ClientId = value; break;
                    case "clientsecret": argumentAction = value => options.ClientSecret = value; break;
                    case "url": argumentAction = value => options.Url = value; break;
                    case "board": argumentAction = value => options.Board = value; break;
                    case "requestTranscripts": options.EnableNewTranscripts = true; break;
                    
                    case "help": return null;

                    default: badArgument = true; break;
                };
            } else if (argumentAction != null)
            {
                argumentAction(arg);
                argumentAction = null;
            } else
                badArgument = true;

            if (badArgument)
            {
                Terminal.WriteError($"Unknown argument '{arg}'");
                return null;
            };
        };

        if (argumentAction != null)
        {
            Terminal.WriteError("No argument specified");
            return null;
        };

        return options;
    }

    private void Run ( string[] args )
    {
        try
        {
            if (!Initialize(args))
                return;

            RunAsync().Wait();
        } catch (Exception e)
        {
            e = e.Unwrap();

            Terminal.WriteError(e.Message);
            throw;
        };
    }

    private async Task RunAsync ()
    {
        do
        {
            var handler = DisplayMenu();
            await handler(_client);
        } while (!_quit);
    }

    private void ShowHelp ()
    {
        Terminal.WriteLine("-clientId <id> where <id> is the client ID");
        Terminal.WriteLine("-clientSecret <secret> where <secret> is the client secret");
        Terminal.WriteLine($"-url <url> where <url> is the base URL (Default = {ProgramOptions.DefaultUrl})");
        Terminal.WriteLine($"-board <board> where <board> is the board code (Default = {ProgramOptions.DefaultBoard})");
        Terminal.WriteLine("-requestTranscripts requests permission to create new transcripts (account must already have been granted permissions when account created)");
    }

    private UsmleApiClient _client;    

    private ITerminal Terminal => ConsoleTerminal.Default;

    private bool _quit;
    private ProgramOptions _options;
    #endregion
}
