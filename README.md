AppSettings:

{
  "DatabaseSettings": {
    "SqlServer": "localhost",
    "DatabaseName": "ChallengeN5",
    "DbUser": "sa",
    "DbPassword": "N5challenge-enzo"
  },
  "ElasticSearchSettings": {
    "Uri": "http://elasticsearch:9200",
    "DefaultIndex": "permissions"
  },
  "HttpClientPolicySettings": {
    "MaxRetries": 3,
    "GlobalTimeout": 300,
    "RetryTimeout": 300,
    "RetryWaitingTime": 250
  },
  "Sieve": {
    "CaseSensitive": false,
    "ThrowExceptions": true
  }
}
