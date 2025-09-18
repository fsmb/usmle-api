# Get Summary

Gets a summary of available transcripts given the criteria.

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
GET {baseUrl}/v1/me/transcripts/??/summary?fromDate=2025-05-01&toDate=2025-05-02
```

#### Sample Response

Status code: 200

```json
[
    ??
    ...
]
```

For more examples go to [samples](/samples/).
