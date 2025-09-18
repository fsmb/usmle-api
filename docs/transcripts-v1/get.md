# Get Transcript

Gets the current USMLE transcript for a USMLE ID.

```http
GET {baseUrl}/v1/{board}/transcripts/{usmleId}/current
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
| 200 OK | [Transcript](/docs/definitions/transcript.md) | Success |
| 204 No Content | | There is no transcript for the physician |
| 400 Bad Request | | USMLE ID is invalid |
| 403 Forbidden | | Board code is invalid |

## Security

### Scopes

| Scope | Description |
| -|-|
| usmle.read | Grants permission to read USMLE transcripts. |

## Examples

[Get the Transcript](#get-the-transcript)
***

### Get the Transcript

#### Sample Request

```http
GET {baseUrl}/v1/me/transcripts/??/current
```

#### Sample Response

Status code: 200

*Note: Output is elided. Refer to [Transcript](/docs/definitions/transcript.md) for a complete example.*

```json
{
    ??
    ...
}
```

For more examples go to [samples](/samples/).
