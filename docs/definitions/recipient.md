# Recipient

Recipient information

| Name | Type | Required | Description |
| - | - | - | - |
| name | string (len: 100) | Yes | Recipient name |
| addressLines | string[] | No | Address lines |
| city | string (len: 50) | No | City |
| stateOrProvince | [StateOrProvince](state-or-province.md) | Yes | State or province |
| postalCode | string (len: 9) | No | Postal code |

*Note: Any fields marked as deprecated will be removed in a future version of the API. New code should not rely on these fields. Existing code should be updated to use alternative fields.*
