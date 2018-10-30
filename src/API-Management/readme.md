## API Management with Traefik

I found a great example of Traefik for developers:
https://jtreminio.com/blog/traefik-on-docker-for-web-developers/

## First

Create network first

```sh
docker network create --driver bridge traefik_webgateway
```

## Second

- Run `docker-compose up` in /traefik in a PowerShell window
- Run `docker-compose up` in /app in a PowerShell window
- Open `http://mywebapp.localhost/` with your favourite browser

You stop this sample if you close your PowerShell windows.