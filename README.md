# ampro

## Quick deploy

- Requirements: installed Docker, docker compose, dotnet, dotnet-ef, ~6GB of available storage
- Steps:
    1. clone this repo
    2. cd <main_repo_dir>
    3. Deploy
        - Linux
        ```
        ./deploy.sh
        ```
        - Windows
        ```
        .\deploy.ps1
        ```
    4. Test
    - check if services are up
    ```
    sudo docker ps -a
    ```
    - client app is on http://localhost or http://localhost:3000/ampro

    5. Cleanup
        - Linux
        ```
        ./cleanup.sh
        ```
        - Windows
        ```
        .\cleanup.ps1
        ```