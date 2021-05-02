# REST.API - rules:

1. We should use simple and common naming convention. kebab-case is perfect here. Smallcase and "-".
2. Application and backend should be developed separately. For this reason we have to use simple naming enpoints (route names).

Standard REST:
GET /movies
POST /movies
UPDATE /movies
DELETE /movies

instead of naming like: 
"GET /getMovies"

It is highly advisable to use nouns rather than verbs.
For the same reason, we should use plural nouns names than singular ones.

3. To differentiate funcionality of request we should use functions with parameters like:
GET /movies //Gets the collection
GET /movies/:id //Gets specified movie by type

4. The response should contain appropriate response code and the instruction how to solve the error.
The most common ones are:
200 OK
304 Not modified
400 Bad Request
401 Unauthorized
403 Forbidden
404 Not found
500 Internal server error
 
 
