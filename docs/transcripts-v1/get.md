# Get Transcript

Gets the current USMLE transcript for a USMLE ID.

*Note: Refer to [Transcript Availability](availability.md) for information on when Transcripts will be available.*

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

[Get the Transcript](#get-the-transcript) \
[Transcript Not Available](#transcript-not-available)
***

### Get the Transcript

#### Sample Request

```http
GET {baseUrl}/v1/me/transcripts/73013245/current
```

#### Sample Response

Status code: 200

*Note: Output is elided. Refer to [Transcript](/docs/definitions/transcript.md) for a complete example.*

```json
{
    "usmleId": "73013245",
    "fid": "999999949",
    "recipient": {
        "name": "TEXAS MEDICAL BOARD",        
        "stateOrProvince": {
            "code": "TX",
            "description": "TEXAS"         
        }
    },
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
    "exams": [
        {
            "examCode": "STEP1",
            "examDescription": "USMLE STEP 1",
            "examDate": "2012-11-23T00:00:00",
            "passFailStatus": "Undetermined",
            "score": 0,
            "minimumPassScore": 0,
            "note": "Score Not Available",
            "scoreAvailableDate": "2012-12-12T00:00:00",
            "hasIrregularBehavior": false,
            "irregularBehavior": null
        },
        {
            "examCode": "STEP2CK",
            "examDescription": "USMLE STEP 2 CK",
            "examDate": "2010-04-28T00:00:00",
            "passFailStatus": "Fail",
            "score": 160,
            "minimumPassScore": 184,
            "note": null,
            "scoreAvailableDate": "2010-05-19T00:00:00",
            "hasIrregularBehavior": false,
            "irregularBehavior": null
        },
        {
            "examCode": "STEP2CK",
            "examDescription": "USMLE STEP 2 CK",
            "examDate": "2012-10-09T00:00:00",
            "passFailStatus": "Undetermined",
            "score": 0,
            "minimumPassScore": 0,
            "note": "Score Not Available",
            "scoreAvailableDate": "2012-10-31T00:00:00",
            "hasIrregularBehavior": false,
            "irregularBehavior": null
        }
    ],
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
        },
        "step3": {
            "lastExamDate": null,
            "lastPassFailStatus": null,
            "attempts": 0
        }
    },
    ...
}
```

***

### Transcript Not Available

This scenario occurs when a transcript has been requested, either by the physician or through an API request, but has not yet been made available. Clients should try again later if they are sure a transcript has been requested.

#### Sample Request

```http
GET {baseUrl}/v1/me/transcripts/73013245/current
```

#### Sample Response

Status code: 204

For more examples go to [samples](/samples/).
