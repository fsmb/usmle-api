# Transcript

Physician transcript

| Name | Type | Required | Description |
| - | - | - | - |
| usmleId | string (format: digits, len: 8) | Yes | USMLE ID |
| fid | string (format: digits, len: 9) | Yes | FID of physician |
| recipient | [Recipient](recipient.md) | Yes | Recipient information |
| information | [TranscriptInformation](transcript-information.md) | Yes | Transcript information |
| legalName | [Name](name.md) | Yes | Legal name |
| identity | [Identification](identification.md) | Yes | Identity information |
| otherNames | [Name[]](name.md) | No | Other names |
| exams | [Exam[]](exam.md) | Yes | Exam history |
| examSummary | [ExamSummary](exam-summary.md) | Yes | Exam history summary |
| hasNonAdministrativeIrregularBehavior | boolean | Yes | Is there non-administrative irregular behavior? |
| nonAdministrativeIrregularBehavior | [IrregularBehavior[]](irregular-behavior.md) | No | Non-administrative Irregular behavior |
| boardActions | [BoardActions](board-actions.md) | Yes | Board action information |
| nbme | [NbmeInformation](nbme-information.md) | Yes | NBME information |
| ecfmg | [EcfmgInformation](ecfmg-information.md) | Yes | ECFMG information |
| flex | [FlexInformation](flex-information.md) | Yes | FLEX information |
| ice | [IceInformation](ice-information.md) | Yes | ICE information |
| usmle | [UsmleInformation](usmle-information.md) | Yes | USMLE information |

*Note: Any fields marked as deprecated will be removed in a future version of the API. New code should not rely on these fields. Existing code should be updated to use alternative fields.*

## Example

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
        "hasTranscriptRequest": true,
        "transcriptSentDate": "2025-09-17T00:00:00"
    },
    "legalName": {
        "firstName": "Robert",
        "middleName": "More",
        "lastName": "Finaling-Final",
        "suffix": "Jr"
    },
    "identity": {
        "birthDate": "1945-01-06T00:00:00"
    },    
    "exams": [        
        {
            "examCode": "STEP1",
            "examDescription": "USMLE STEP 1",
            "examDate": "2011-10-25T00:00:00",
            "passFailStatus": "Pass",
            "score": 206,
            "minimumPassScore": 188,
            "note": null,
            "scoreAvailableDate": "2011-11-16T00:00:00",
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
        },
        {
            "examCode": "STEP2CS",
            "examDescription": "USMLE STEP 2 CS",
            "examDate": "2012-12-14T00:00:00",
            "passFailStatus": "Undetermined",
            "score": 0,
            "minimumPassScore": 0,
            "note": "Score Not Available",
            "scoreAvailableDate": "2013-01-30T00:00:00",
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
        "step2CS": {
            "lastExamDate": "2012-12-14T00:00:00",
            "lastPassFailStatus": "Undetermined",
            "attempts": 2
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
