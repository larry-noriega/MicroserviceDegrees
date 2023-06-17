const PROXY_CONFIG = [
  {
    context: [
      "/api/persons"
    ],
    target: "https://localhost:7239",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
