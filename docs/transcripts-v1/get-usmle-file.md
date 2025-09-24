# Get USMLE Transcript File

 Gets the USMLE transcript file for a USMLE ID.

```http
GET {baseUrl}/v1/{board}/transcripts/{usmleId}/files/usmle
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
| 200 OK | PDF file | Success |
| 400 Bad Request | | USMLE ID is invalid |
| 404 Not Found | | There is no transcript for the physician |
| 403 Forbidden | | Board code is invalid |

## Security

### Scopes

| Scope | Description |
| -|-|
| usmle.read | Grants permission to read USMLE transcripts. |

## Examples

[Get the File](#get-the-file)
***

### Get the File

#### Sample Request

```http
GET {baseUrl}/v1/me/transcripts/??/files/usmle
```

#### Sample Response

Status code: 200

Body: PDF file

For more examples go to [samples](/samples/).
