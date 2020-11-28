# Simple Payment Gateway
This is a simple payment gateway that can easiliy be connected with a banks api to process payments from customer to merchant. Please note that this a simple implementation that does not guarantee safe payments. I recommend to use this only for educational purposes.

## User Guide
The gateway works in three simple steps. As there is no official api registration process, we first have safe the merchants payment details by sending a simple post request. The response to this request should include the merchants identifier. It's important to remember this identifier as thus far there is no endpoint to reset it.
```
REQUEST:
curl --location --request POST 'http://localhost:62177/payments/set/merchant/details' \
--header 'Content-Type: application/json' \
--data-raw '{
    "Name": "Amazon",
    "CardNumber": "Test",
    "CVV": "1"
}'

RESPONSE:
{
    "MerchantIdentifier": "a2c18568-0bf3-4318-ad64-ca1381153649",
    "Success": true
}
```


With the merchants identifier and all other details of the payment we would like to process we can then sent a simple post request as such:
```
curl --location --request POST 'http://localhost:62177/payments/process' \
--header 'Content-Type: application/json' \
--data-raw '{
    "MerchantIdentifier": "a2c18568-0bf3-4318-ad64-ca1381153649",
    "IsPayout": true,
    "CardNumber": "Test",
    "Name": "Max Mustermann",
    "Amount": 352,
    "Reference": "Test",
    "Currency": "USD",
    "CVV": "1",
    "ExpiryDate": "01.01.2040"
}'
```
The response will be boolean value indication whether the process was a success, and a payment id that can later be used to retrieve the payment information. Again, thus far there is no endpoint to retrieve this id if lost.
```
{
    "PaymentId": "822f4b34-c3a9-4cf3-9194-9a26b12770ee",
    "Success": true
}
```


At last, with a simple GET request with the payment id as a url parameter, we can retrieve the payment information.
```
curl --location --request GET 'http://localhost:62177/payments/822f4b34-c3a9-4cf3-9194-9a26b12770ee'
```
The result will include all important information with the card number being masked.
```
{
    "Id": "822f4b34-c3a9-4cf3-9194-9a26b12770ee",
    "CardNumber": "Test",
    "Amount": 352.0,
    "Currency": "USD",
    "Reference": null,
    "Cvv": "1",
    "Success": true,
    "ExpiryDate": "2040-01-01T00:00:00"
}
```
