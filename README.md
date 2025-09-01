## Notes: 

### General
- Rate Limiter?
- If search query, wait with a buffer for user to stop clicking.
- Add relevant error messages
- maybe be more granular with service returns, to differentiate between Failed, Success, BadRequest and Notfound etc.
- FluentValidation
### Booking
- If Wanted Seats > Available seats, highlight other dates and times when available.
- Implement holding/reservation with countdown
- Search for only time/date/seats?
- Abstracting EF Core Unit of Work for better decoupling in the transaction???
- Is the client side doing the point and click or the backend?
- Should I restrict bigger groups to find one big table or enable them to add tables together?
