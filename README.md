# Anime Network API
This API enables users to login, create, edit and update anime. Users can also view anime based on the studios which produces them and the genres they belong to. 
All responses are formatted in  `content-type` of `application/json` but the input format can be either `application/xml` or `application/json`

## Deployment 

This api has been deployed on heroku and can be accessed using this [link](https://a-network.herokuapp.com)

![Alt Text](https://media.giphy.com/media/USteqyonq8hVDJ9UHI/giphy.gif)

## Login
**You send:**  Your  login credentials.
**You receive:** An `API-Token` with which you can make further actions.

**Endpoint:**
```json
POST /api/v1/user/login HTTP/1.1
Accept: application/json
Content-Type: application/json

{
    "username": "username@gmail.com",
    "password": "password@12345" 
}
```
**Successful Response:**
```json
HTTP/1.1 200 OK
Request URL: https://a-network.herokuapp.com/api/v1/user/login
Content-Type: application/json

{
   "code": 200,
  "responseMessage": "Login Success",
  "returnObject": {
    "id": "203f5f8e-6e34-47f2-9416-a858e5d14846",
    "email": "admisnistrator@gmail.com",
    "firstName": "User",
    "lastName": "Name",
    "phoneNumber": null,
    "age": 0,
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9",
    "refreshToken": null,
    "expiresOn": "08/27/2020 12:18:12"
  }
}
```
**Failed Response:**
```json
HTTP/1.1 401 Unauthorized
Request URL: https://a-network.herokuapp.com/api/v1/user/login
Content-Type: application/json

"Incorrect Username or Password"

``` 

## Usage

You can use the token obtained from the login endpoint to access other endpoints
