
# Introduction
Welcome to the Stocks API.

# HTTP Responses
A HTTP response indicates the result of a request to the API.
More information can be found [here](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status).

## Success
Successful requests to the API will return responses with status codes in the ```200``` range.

| Code | Name | Description |
| ----------- | ----------- | ----------- |
| 200 | OK | The request succeeded and content is returned. |
| 204 | No Content | The request succeeded and no content is returned. |

## Client Errors
Unsuccessful requests to the API due to client errors will return responses with status codes in the ```400``` range.

| Code | Name | Description |
| ----------- | ----------- | ----------- |
| 400 | Bad Request | The server cannot or will not process the request due to something that is perceived to be a client error. |
| 401 | Unauthorized | Although the HTTP standard specifies "unauthorized", semantically this response means "unauthenticated". That is, the client must authenticate itself to get the requested response. |
| 403 | Forbidden | The client does not have access rights to the content; that is, it is unauthorized, so the server is refusing to give the requested resource. Unlike 401 Unauthorized, the client's identity is known to the server. |
| 404 | Not Found | The server can not find the requested resource. |
| 422 | Unprocessable Entity | The request was well-formed but was unable to be followed due to semantic errors. |

## Server Errors
Unsuccessful requests to the API due to server errors will return responses with status codes in the ```500``` range.

| Code | Name | Description |
| ----------- | ----------- | ----------- |
| 500 | Internal Server Error | The server has encountered a situation it does not know how to handle and cannot return a meaningful error response. |
