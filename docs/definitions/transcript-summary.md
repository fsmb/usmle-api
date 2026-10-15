# TranscriptSummary

Physician transcript summary

| Name | Type | Required | Description |
| - | - | - | - |
| usmleId | string (format: digits, len: 8) | Yes | USMLE ID |
| fid | string (format: digits, len: 9) | Yes | FID of physician |
| sentDate | string (date) | Yes | **(Deprecated: Use sentDateUtc)** Sent date |
| sentDateUtc | string (datetime) | Yes | Sent datetime, in UTC |
| legalName | [Name](name.md) | Yes | Legal name |
| information | [TranscriptInformation](transcript-information.md) | Yes | Transcript information |
| examSummary | [ExamSummary](exam-summary.md) | Yes | Exam history summary |

*Note: Any fields marked as deprecated will be removed in a future version of the API. New code should not rely on these fields. Existing code should be updated to use alternative fields.*
