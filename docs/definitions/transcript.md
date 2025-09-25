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
| nonAdministrativeIrregularBehavior | [IrregularBehavior[]](irregular-behavior.md) | No | Non-administrative irregular behavior |
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
        "addressLines": [],
        "city": null,
        "stateOrProvince": {
            "code": "TX",
            "description": "TEXAS",
            "countryCode": null,
            "countryDescription": null
        },
        "postalCode": null
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
        "suffix": "Jr"
    },
    "identity": {
        "birthDate": "1945-01-06T00:00:00"
    },
    "otherNames": [],
    "exams": [
        {
            "examCode": "STEP1",
            "examDescription": "USMLE STEP 1",
            "examDate": "2009-11-19T00:00:00",
            "passFailStatus": "Fail",
            "score": 159,
            "minimumPassScore": 185,
            "note": null,
            "scoreAvailableDate": "2009-12-09T00:00:00",
            "hasIrregularBehavior": false,
            "irregularBehavior": null
        },
        {
            "examCode": "STEP1",
            "examDescription": "USMLE STEP 1",
            "examDate": "2010-03-04T00:00:00",
            "passFailStatus": "Fail",
            "score": 176,
            "minimumPassScore": 188,
            "note": null,
            "scoreAvailableDate": "2010-03-24T00:00:00",
            "hasIrregularBehavior": false,
            "irregularBehavior": null
        },
        {
            "examCode": "STEP1",
            "examDescription": "USMLE STEP 1",
            "examDate": "2010-08-17T00:00:00",
            "passFailStatus": "Fail",
            "score": 175,
            "minimumPassScore": 188,
            "note": null,
            "scoreAvailableDate": "2010-09-08T00:00:00",
            "hasIrregularBehavior": false,
            "irregularBehavior": null
        },
        {
            "examCode": "STEP1",
            "examDescription": "USMLE STEP 1",
            "examDate": "2010-10-16T00:00:00",
            "passFailStatus": "Fail",
            "score": 176,
            "minimumPassScore": 188,
            "note": null,
            "scoreAvailableDate": "2010-11-10T00:00:00",
            "hasIrregularBehavior": false,
            "irregularBehavior": null
        },
        {
            "examCode": "STEP1",
            "examDescription": "USMLE STEP 1",
            "examDate": "2010-12-04T00:00:00",
            "passFailStatus": "Fail",
            "score": 186,
            "minimumPassScore": 188,
            "note": null,
            "scoreAvailableDate": "2011-01-05T00:00:00",
            "hasIrregularBehavior": false,
            "irregularBehavior": null
        },
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
            "examDate": "2010-11-09T00:00:00",
            "passFailStatus": "Fail",
            "score": 173,
            "minimumPassScore": 189,
            "note": null,
            "scoreAvailableDate": "2010-12-01T00:00:00",
            "hasIrregularBehavior": false,
            "irregularBehavior": null
        },
        {
            "examCode": "STEP2CK",
            "examDescription": "USMLE STEP 2 CK",
            "examDate": "2011-09-06T00:00:00",
            "passFailStatus": "Pass",
            "score": 235,
            "minimumPassScore": 189,
            "note": null,
            "scoreAvailableDate": "2011-09-28T00:00:00",
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
            "examDate": "2010-06-04T00:00:00",
            "passFailStatus": "Pass",
            "score": 0,
            "minimumPassScore": 0,
            "note": null,
            "scoreAvailableDate": "2010-08-18T00:00:00",
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
        "step2": {
            "lastExamDate": null,
            "lastPassFailStatus": null,
            "attempts": 0
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
    "hasNonAdministrativeIrregularBehavior": true,
    "nonAdministrativeIrregularBehavior": [
        {
            "description": "Falsified Information",
            "note": "The USMLE Program determined that this individual engaged in IRREGULAR BEHAVIOR, specifically, Falsified Information, that was not in connection with an administration shown on this transcript. Information regarding the nature of the irregular behavior and the program’s determination of the Committee is available. If such information is not enclosed with this transcript, it may be obtained by contacting the organization from which you received the transcript or the USMLE Secretariat, 3750 Market Street, Philadelphia, PA 19104, telephone (215) 590-9700."
        }
    ],
    "boardActions": {
        "hasBoardActions": true,
        "boardActionDescription": "A search of the Physician Data Center of the Federation of State Medical Boards (FSMB) reveals information on this examinee. The Physician Data Center Report is enclosed."
    },
    "nbme": {
        "hasPartHistory": false,
        "partHistoryDescription": null
    },
    "ecfmg": {
        "hasPartHistory": false,
        "partHistoryDescription": null,
        "hasLastCsa": false,
        "lastCsaDescription": null
    },
    "flex": {
        "hasFlex": false,
        "flexDescription": null
    },
    "ice": {
        "hasIce": false,
        "iceDescription": null
    },
    "usmle": {
        "step2CSDescription": "The USMLE Step 2 CS examination was last administered March 16, 2020. Examinees with a failing outcome may not have had an opportunity to retest. The USMLE defines successful completion of its examination sequence as passing Step 1, Step 2 CK, and Step 3."
    }
}
```
