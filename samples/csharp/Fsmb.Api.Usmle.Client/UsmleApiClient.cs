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
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Threading;
using System.Threading.Tasks;

using Fsmb.Api.Usmle.Client.Authentication;
using Fsmb.Api.Usmle.Client.Models;

namespace Fsmb.Api.Usmle.Client
{
    /// <summary>Provides an HTTP client for working with the FSMB Usmle API.</summary>
    public class UsmleApiClient
    {
        #region Construction

        /// <summary>Initializes an instance of the <see cref="UsmleApiClient"/> class.</summary>
        protected UsmleApiClient ()
        { }

        /// <summary>Initializes an instance of the <see cref="UsmleApiClient"/> class.</summary>
        /// <param name="client">HTTP client to use.</param>
        /// <remarks>
        /// Credentials must be configured on the HTTP client when using this overload.
        /// </remarks>
        public UsmleApiClient ( HttpClient client ) : this(client, null, null)
        {
        }

        /// <summary>Initializes an instance of the <see cref="UsmleApiClient"/> class.</summary>
        /// <param name="client">HTTP client to use.</param>
        /// <param name="board">Board to use.</param>
        /// <remarks>
        /// Credentials must be configured on the HTTP client when using this overload.
        /// </remarks>
        public UsmleApiClient ( HttpClient client, string board ) : this(client, new UsmleApiClientOptions() { Board = board }, null)
        {
        }

        /// <summary>Initializes an instance of the <see cref="UsmleApiClient"/> class.</summary>
        /// <param name="client">HTTP client to use.</param>
        /// <param name="credentials">Credentials to use.</param>
        public UsmleApiClient ( HttpClient client, UsmleApiClientCredentials credentials ) : this(client, new UsmleApiClientOptions(), credentials)
        {
        }

        /// <summary>Initializes an instance of the <see cref="UsmleApiClient"/> class.</summary>
        /// <param name="client">HTTP client to use.</param>
        /// <param name="credentials">Credentials to use.</param>
        /// <param name="options">API options</param>
        public UsmleApiClient ( HttpClient client, UsmleApiClientOptions options, UsmleApiClientCredentials credentials )
        {         
            Client = client;

            var board = options?.Board ?? "me";
            _baseUrl = $"v1/{board}";

            if (credentials != null)
            {
                _credentials = new UsmleApiClientCredentials() {                    
                    ClientId = credentials.ClientId,
                    ClientSecret = credentials.ClientSecret,
                };
            };
        }
        #endregion

        /// <summary>Gets a summary of available transcripts given the criteria.</summary>
        /// <param name="request">The transcripts to retrieve.</param>        
        /// <returns>List of transcripts that meet the criteria.</returns>
        public virtual PagedOffsetList<TranscriptSummary> GetAvailableTranscriptsSummary ( TranscriptSummaryRequest request )
                    => GetAvailableTranscriptsSummaryAsync(request, CancellationToken.None).GetAwaiter().GetResult();

        /// <summary>Gets a summary of available transcripts given the criteria.</summary>
        /// <param name="request">The transcripts to retrieve.</param>        
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>List of transcripts that meet the criteria.</returns>
        public virtual async Task<PagedOffsetList<TranscriptSummary>> GetAvailableTranscriptsSummaryAsync ( TranscriptSummaryRequest request, CancellationToken cancellationToken = default )
        {
            var url = GetResourceUrl("transcripts/summary");

            // Add query parameters
            if (request != null)
            {
                var query = ToQueryString(request);
                if (!String.IsNullOrEmpty(query))
                    url = String.Concat(url, "?", query);
            }

            var message = new HttpRequestMessage(HttpMethod.Get, url);
            await PrepareRequestAsync(message, cancellationToken).ConfigureAwait(false);                                   

            using (var response = await Client.SendAsync(message, cancellationToken).ConfigureAwait(false))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound || response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    return new PagedOffsetList<TranscriptSummary>();

                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<PagedOffsetList<TranscriptSummary>>(cancellationToken).ConfigureAwait(false);
            }            
        }


        /// <summary>Gets the current USMLE transcript for a USMLE ID.</summary>
        /// <param name="usmleId">The USMLE ID of the physician.</param>        
        /// <returns>Transcript, if any.</returns>
        public virtual Transcript GetCurrentTranscript ( string usmleId )
                    => GetCurrentTranscriptAsync(usmleId, CancellationToken.None).GetAwaiter().GetResult();

        /// <summary>Gets the current USMLE transcript for a USMLE ID.</summary>
        /// <param name="usmleId">The USMLE ID of the physician.</param>        
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Transcript, if any.</returns>
        public virtual async Task<Transcript> GetCurrentTranscriptAsync ( string usmleId, CancellationToken cancellationToken = default )
        {            
            var url = GetResourceUrl(String.Join("/", "transcripts", usmleId, "current"));

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            await PrepareRequestAsync(request, cancellationToken).ConfigureAwait(false);

            using (var response = await Client.SendAsync(request, cancellationToken).ConfigureAwait(false)) 
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound || response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    return null;

                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<Transcript>(cancellationToken).ConfigureAwait(false);
            };
        }

        /// <summary>Gets the USMLE transcript file for a USMLE ID.</summary>
        /// <param name="usmleId">The USMLE ID of the physician.</param>        
        /// <returns>Transcript PDF, if any.</returns>
        public virtual byte[] GetUsmleTranscriptFile ( string usmleId )
                    => GetUsmleTranscriptFileAsync(usmleId, CancellationToken.None).GetAwaiter().GetResult();

        /// <summary>Gets the USMLE transcript file for a USMLE ID.</summary>
        /// <param name="usmleId">The USMLE ID of the physician.</param>        
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Transcript PDF, if any</returns>
        public virtual async Task<byte[]> GetUsmleTranscriptFileAsync ( string usmleId, CancellationToken cancellationToken = default )
        {
            var url = GetResourceUrl(String.Join("/", "transcripts", usmleId, "files/usmle"));

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            await PrepareRequestAsync(request, cancellationToken).ConfigureAwait(false);

            using (var response = await Client.SendAsync(request, cancellationToken).ConfigureAwait(false))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound || response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    return null;

                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
            }
        }

        /// <summary>Requests a new transcript be generated for the given USMLE ID.</summary>
        /// <param name="usmleId">The USMLE ID of the physician.</param>                
        /// <remarks>
        /// Note: Transcripts can take 24 hours or more to be created. Once requested clients should periodically attempt to get the updated transcript until it is generated.
        /// <para/>
        /// A new transcript can only be requested if the following conditions apply:
        /// <list type="bullet">
        /// <item>The physician has previously requested a transcript to the entity.</item>
        /// <item>The transcript has not expired.</item>
        /// <item>A new transcript has not been requested in the last 24 hours.</item>
        /// </list>
        /// </remarks>
        public virtual void RequestNewTranscript ( string usmleId )
                    => RequestNewTranscriptAsync(usmleId, CancellationToken.None).GetAwaiter().GetResult();

        /// <summary>Requests a new transcript be generated for the given USMLE ID.</summary>
        /// <param name="usmleId">The USMLE ID of the physician.</param>                
        /// <remarks>
        /// Note: Transcripts can take 24 hours or more to be created. Once requested clients should periodically attempt to get the updated transcript until it is generated.
        /// <para/>
        /// A new transcript can only be requested if the following conditions apply:
        /// <list type="bullet">
        /// <item>The physician has previously requested a transcript to the entity.</item>
        /// <item>The transcript has not expired.</item>
        /// <item>A new transcript has not been requested in the last 24 hours.</item>
        /// </list>
        /// </remarks>
        public virtual async Task RequestNewTranscriptAsync ( string usmleId, CancellationToken cancellationToken = default )
        {
            var url = GetResourceUrl(String.Join("/", "transcripts", usmleId));

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            await PrepareRequestAsync(request, cancellationToken).ConfigureAwait(false);

            using (var response = await Client.SendAsync(request, cancellationToken).ConfigureAwait(false))
            {                
                switch (response.StatusCode) {
                    case HttpStatusCode.NotFound: throw new InvalidOperationException("Physician does not have a previous request or it has expired.");
                    case HttpStatusCode.Conflict: throw new InvalidOperationException("A new transcript has already been requested recently, wait for a while and try again.");

                    //Handle regular errors
                    default: response.EnsureSuccessStatusCode(); break;
                }                
            }
        }

        #region Protected Members

        /// <summary>Gets the underlying HTTP client.</summary>
        protected HttpClient Client { get; }

        protected async Task<OAuthAccessToken> GetAccessTokenAsync ( CancellationToken cancellationToken )
        {
            //If the access token is still valid then use it
            if ((_accessToken?.ExpirationDate ?? DateTime.MinValue).AddMinutes(5) > DateTime.Now)
                return _accessToken;

            _accessToken = await Client.AuthenticateAsync(_credentials, cancellationToken).ConfigureAwait(false);
            
            return _accessToken;
        }

        protected string GetResourceUrl ( string resource ) => String.Join("/", _baseUrl, resource);        

        protected virtual async Task PrepareRequestAsync ( HttpRequestMessage request, CancellationToken cancellationToken )
        {
            if (_credentials != null)
            {
                var token = await GetAccessTokenAsync(cancellationToken).ConfigureAwait(false);

                request.WithBearerToken(token.AccessToken);
            };
        }

        #endregion

        #region Private Members

        private static string ToQueryString ( TranscriptSummaryRequest request )
        {
            var items = new List<string>();

            items.Add($"fromDate={request.FromDate:yyyy-MM-dd}");
            items.Add($"toDate={request.ToDate:yyyy-MM-dd}");
            if (!String.IsNullOrEmpty(request.OrderBy))
                items.Add($"orderBy={WebUtility.UrlEncode(request.OrderBy)}");
            if (request.Limit.HasValue)
                items.Add($"limit={request.Limit}");
            if (request.Offset.HasValue)
                items.Add($"offset={request.Offset}");

            return String.Join("&", items);
        }

        private readonly UsmleApiClientCredentials _credentials;
        private readonly string _baseUrl;

        private OAuthAccessToken _accessToken;
        #endregion
    }
}
