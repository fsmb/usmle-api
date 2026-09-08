# USMLE API

The USMLE API provides access to USMLE exam transcripts to state boards. Click [here](https://www.fsmb.org/transcripts) for more information.

Refer to the [Getting Started with FSMB APIs](https://github.com/fsmb/api-docs) guide to learn more general information about FSMB APIs, terminology, authentication, FSMB codes and more.
For more information and to begin using this API please contact FSMB [here](mailto:transcripts@fsmb.org).

- URL
  - Demo: `https://services-usmle-demo.fsmb.org/`
  - Production: `https://services-usmle.fsmb.org/`
- Authentication URL `<baseUrl>/connect/token`
- [Postman Workspace](https://www.postman.com/crimson-shadow-2749/workspace/public-fsmb/collection/1384052-a84abae4-d4fa-4074-8e2f-48a980f3f25f?action=share&source=copy-link&creator=1384052)
- OpenAPI Specification: [JSON](https://services-usmle-demo.fsmb.org/openapi/v1.json) [YAML](https://services-usmle-demo.fsmb.org/openapi/v1.yaml)

[<img src="https://run.pstmn.io/button.svg" alt="Run In Postman" style="width: 128px; height: 32px;">](https://app.getpostman.com/run-collection/1384052-a84abae4-d4fa-4074-8e2f-48a980f3f25f?action=collection%2Ffork&source=rip_markdown&collection-url=entityId%3D1384052-a84abae4-d4fa-4074-8e2f-48a980f3f25f%26entityType%3Dcollection%26workspaceId%3D58240218-129c-4c2c-a71a-139a2efabdb2#?env%5BUSMLE%20(Demo)%5D=W3sia2V5IjoiYmFzZVVybCIsInZhbHVlIjoiaHR0cHM6Ly9zZXJ2aWNlcy11c21sZS1kZW1vLmZzbWIub3JnIiwiZW5hYmxlZCI6dHJ1ZSwic2Vzc2lvblZhbHVlIjoiaHR0cHM6Ly9zZXJ2aWNlcy11c21sZS1kZW1vLmZzbWIub3JnIiwiY29tcGxldGVTZXNzaW9uVmFsdWUiOiJodHRwczovL3NlcnZpY2VzLXVzbWxlLWRlbW8uZnNtYi5vcmciLCJzZXNzaW9uSW5kZXgiOjB9LHsia2V5IjoiY2xpZW50SWQiLCJ2YWx1ZSI6IkRPX05PVF9TRVRfSEVSRSIsImVuYWJsZWQiOnRydWUsInR5cGUiOiJzZWNyZXQiLCJzZXNzaW9uVmFsdWUiOiJET19OT1RfU0VUX0hFUkUiLCJjb21wbGV0ZVNlc3Npb25WYWx1ZSI6IkRPX05PVF9TRVRfSEVSRSIsInNlc3Npb25JbmRleCI6MX0seyJrZXkiOiJjbGllbnRTZWNyZXQiLCJ2YWx1ZSI6IkRPX05PVF9TRVRfSEVSRSIsImVuYWJsZWQiOnRydWUsInR5cGUiOiJzZWNyZXQiLCJzZXNzaW9uVmFsdWUiOiJET19OT1RfU0VUX0hFUkUiLCJjb21wbGV0ZVNlc3Npb25WYWx1ZSI6IkRPX05PVF9TRVRfSEVSRSIsInNlc3Npb25JbmRleCI6Mn0seyJrZXkiOiJjbGllbnRTY29wZXMiLCJ2YWx1ZSI6InVzbWxlLnJlYWQiLCJlbmFibGVkIjp0cnVlLCJ0eXBlIjoiZGVmYXVsdCIsInNlc3Npb25WYWx1ZSI6InVzbWxlLnJlYWQiLCJjb21wbGV0ZVNlc3Npb25WYWx1ZSI6InVzbWxlLnJlYWQiLCJzZXNzaW9uSW5kZXgiOjN9XQ==)

## Change Log

| Date | Release Notes |
| - | - |
| Sept 2026 | [Release Notes](relnotes/relnotes-202609.md) |
| May 2025 | Initial version |

## Security

### Scopes

| Scope | Description |
| - | - |
| usmle.read | Grants permission to read USMLE transcripts. |
| usmle.transcript_create | Grants permission to request new transcripts. |

## Resources

- [Transcripts](docs/transcripts-v1/readme.md)
