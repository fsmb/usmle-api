# Get Summary

Gets a summary of available transcripts given the criteria.

*Note: Refer to [Transcript Availability](availability.md) for information on when Transcripts will be available.*

```http
GET {baseUrl}/v1/{board}/transcripts/summary
```

With optional parameters.

```http
GET {baseUrl}/v1/{board}/transcripts/summary?fromDate={fromDate}&toDate={toDate}&orderBy={orderBy}&offset={offset}&limit={limit}
```

## URI Parameters

| Name | In | Required | Type | Description |
| - |-|-|-|-|
| baseUrl | path | True | string | The API URL. |
| board | path | True | string | The board code or `me`. |
| fromDate | query | False | DateTime (format: yyyy-mm-dd) | Start date, inclusive. |
| toDate | query | False | DateTime (format: yyyy-mm-dd) | End date, inclusive. |
| orderBy | query | False | string | Field(s) to order by. (Default: `sentDate`) |
| offset | query | False | number | Number of items to skip. (Default: 0) |
| limit | query | False | number | Number of items to return. (Default: 100) |

This resource supports paging and sorting. The following fields can be ordered.

- `fid`
- `sentDate`
- `usmleId`

*Note: If there are many transcripts then the results will be paged.*

## Responses

| Name | Type | Description |
| - |-|-|
| 200 OK | [TranscriptSummary[]](/docs/definitions/transcript-summary.md) | Success |
| 400 Bad Request | | Criteria is bad |
| 403 Forbidden | | Board code is invalid |

## Security

### Scopes

| Scope | Description |
| -|-|
| usmle.read | Grants permission to read USMLE transcripts. |

## Examples

[Get Summary for One Day](#get-summary-for-one-day)
***

### Get Summary for One Day

Get a summary of transcripts for 1 May 2025.

#### Sample Request

```http
GET {baseUrl}/v1/me/transcripts/73013245/summary?fromDate=2025-05-01&toDate=2025-05-02
```

#### Sample Response

Status code: 200

```json
{
    "metadata": {
        "totalCount": 1,
        "count": 1,
        "offset": 0,
        "limit": 100
    },
    "items": [
        {
            "usmleId": "73013245",
            "fid": "999999949",
            "sentDate": "2025-09-17T00:00:00",
            "information": {
                "hasFcvsProfile": false,
                "fcvsReleaseDate": null,
                "hasTranscriptRequest": true,
                "transcriptSentDate": "2025-09-17T00:00:00"
            },
            "legalName": {
                "firstName": "Robert",
                "middleName": "More",
                "lastName": "Finaling-Final",
                "suffix": "Jr",
                "isSingularName": false
            },
            "examSummary": {
                "step1": {
                    "lastExamDate": "2012-11-23T00:00:00",
                    "lastPassFailStatus": "Undetermined",
                    "attempts": 7
                },
                "step2CK": {
                    "lastExamDate": "2012-10-09T00:00:00",
                    "lastPassFailStatus": "Undetermined",
                    "attempts": 4
                }
            }
        }
    ]    
}
```

For more examples go to [samples](/samples/).
