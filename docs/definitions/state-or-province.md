# StateOrProvince

State or province

| Name | Type | Required | Description |
| - | - | - | - |
| code | string (len: 3) | Yes | State or province code[^1]  |
| description | string (len: 100) | Yes | Description |
| countryCode | string (len: 2) | No | ISO country code[^2] |
| countryDescription | string (len: 100) | No | Country description |

[^1] Refer to [codes](https://github.com/fsmb/api-docs/tree/master/docs/codes) for more information. \
[^2] Refer to [codes](https://github.com/fsmb/api-docs/tree/master/docs/codes) for more information.

*Note: Any fields marked as deprecated will be removed in a future version of the API. New code should not rely on these fields. Existing code should be updated to use alternative fields.*
