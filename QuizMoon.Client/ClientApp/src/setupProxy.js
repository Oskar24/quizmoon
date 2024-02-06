const { createProxyMiddleware } = require('http-proxy-middleware');

const context =  [
  "/api",
  "/account",
  "/css",
  "/img",
];

module.exports = function(app) {
  const appProxy = createProxyMiddleware(context, {
    target: `https://localhost:7204`,
    secure: false,
    headers: {
      Connection: 'Keep-Alive'
    },
    devServer: {
      client: {
        overlay: false
      }
    }
  });

  app.use(appProxy);
};
