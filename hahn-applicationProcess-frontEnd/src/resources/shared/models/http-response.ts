export class HttpResponse<T> {
  title: string;
  errors: Array<string>;
  payload: T;
}


// {
//   "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
//   "title": "One or more validation errors occurred.",
//   "status": 400,
//   "traceId": "00-ca40c0c3c0dfe3479a189accf4c84366-4210359da4e10442-00",
//   "errors": {
//       "PurchaseDate": [
//           "The specified condition was not met for 'Purchase Date'."
//       ],
//       "CountryOfDepartment": [
//           "The specified country doesn't exist."
//       ],
//       "EmailAdressOfDepartment": [
//           "'Email Adress Of Department' is not a valid email address."
//       ]
//   }
// }
