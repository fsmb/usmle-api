# Request New Transcript

Requests a new transcript for the given USMLE ID.

Transcripts can take 24 hours or more to be created. Once requested clients should periodically attempt to get the updated transcript until it is generated. New transcripts cannot be requested more than once a day.

*Note: Refer to [Transcript Availability](availability.md) for information on when Transcripts will be available.*

```http
POST {baseUrl}/v1/{board}/transcripts/{usmleId}
```

## URI Parameters

| Name | In | Required | Type | Description |
| - |-|-|-|-|
| baseUrl | path | True | string | The API URL. |
| board | path | True | string | The board code or `me`. |
| usmleId | path | True | string | The USMLE ID of the physician. |

## Responses

| Name | Type | Description |
| - |-|-|
| 202 Create | | Request was successful and transcript is being created |
| 400 Bad Request | | USMLE ID is invalid |
| 403 Forbidden | | Board code is invalid |
| 404 Not Found | | Physician does not have a previous request or it has expired |
| 409 Conflict | | A new transcript has already been requested recently, wait for a while and try again |

## Security

### Scopes

| Scope | Description |
| -|-|
| usmle.transcript_create | Grants permission to request new transcripts. |

## Examples

[Request a New Transcript](#request-a-new-transcript) \
[Too Soon to Request a New Transcript](#too-soon-to-request-a-new-transcript)
***

### Request a New Transcript

#### Sample Request

```http
POST {baseUrl}/v1/me/transcripts/73013245
```

#### Sample Response

Status code: 202

The request was successfully processed and the transcript is being generated.

### Too Soon to Request a New Transcript

#### Sample Request

```http
POST {baseUrl}/v1/me/transcripts/73013245
```

#### Sample Response

Status code: 409

A transcript has recently been requested and another transcript cannot be requested yet.

For more examples go to [samples](/samples/).
