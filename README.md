# ampro

## Quick deploy  

- Requirements: installed Docker, dotnet, dotnet-ef, ~6GB of available storage
- Steps:
    1. clone this repo
    2. cd to main repo dir
    3. Deploy
    Linux:
    ```
    ./deploy.sh
    ```
    
    4. Test
    - check if services are up
    ```
    sudo docker ps -a
    ```
    - client app is on http://172.23.0.2

    5. Cleanup
    Linux:
    ```
    ./cleanup.sh
    ```