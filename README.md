# aegisops-service-template

Minimal ASP.NET Core service used to generate the AegisOps target applications.

Copy this repository, set `Service:Name` in `src/Service/appsettings.json`, and replace `site-service` in `.github/workflows/ci.yml` with the project slug. Required endpoints are `GET /health` and `GET /version`.

CI builds and tests on GitHub-hosted runners, pushes the image to GHCR, then registers the artifact from a self-hosted runner that can reach AegisOps.
