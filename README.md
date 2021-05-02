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
 
 
