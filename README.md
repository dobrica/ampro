# ampro

## Quick deploy: Only on Linux

- Requirements: installed Docker, docker compose, dotnet, dotnet-ef, ~6GB of available storage
- Steps:
    1. clone this repo
    2. cd <main_repo_dir>
    3. Deploy
    ```
    sudo ./deploy.sh
    ```
    
    4. Test
    - check if services are up
    ```
    sudo docker ps -a
    ```
    - client app is on http://172.23.0.2

    5. Cleanup
    ```
    sudo ./cleanup.sh
    ```