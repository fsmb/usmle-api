# ExamSummaryDetail

Exam summary

| Name | Type | Required | Description |
| - | - | - | - |
| lastExamDate | string (date) | No | Date exam was last taken |
| lastPassFailStatus | string (len: 20) | No | Pass/fail status[^1] |
| attempts | integer | Yes | Number of attempts |

[^1]: Refer to [codes](https://github.com/fsmb/api-docs/tree/master/docs/codes) for more information.

*Note: Any fields marked as deprecated will be removed in a future version of the API. New code should not rely on these fields. Existing code should be updated to use alternative fields.*
