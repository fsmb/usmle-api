# Exam

Exam history

| Name | Type | Required | Description |
| - | - | - | - |
| examCode | string (len: 10) | Yes | Exam code |
| examDescription | string (len: 100) | Yes | Exam description |
| examDate | string (date) | Yes | Date exam was taken |
| passFailStatus | string (len: 20) | No | Pass/fail status[^1] |
| scoreAvailableDate | string (date) | Yes | Date score is available |
| score | integer | No | Score |
| minimumPassScore | integer | No | Minimum passing score |
| note | string (len: 1000) | No | Note |
| hasIrregularBehavior | boolean | Yes | Is there irregular behavior? |
| irregularBehavior | [IrregularBehavior[]](irregular-behavior.md) | No | Irregular behavior |

[^1]: Refer to [codes](pass-fail-codes.md) for more information.

Possible `examCode` values include:

- `STEP1`
- `STEP2CS`
- `STEP2CK`
- `STEP3`

*Note: Any fields marked as deprecated will be removed in a future version of the API. New code should not rely on these fields. Existing code should be updated to use alternative fields.*
