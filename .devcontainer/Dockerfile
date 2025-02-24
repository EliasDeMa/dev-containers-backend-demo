FROM mcr.microsoft.com/devcontainers/dotnet:1-9.0-bookworm

# [Optional] Uncomment this section to install additional OS packages.
# RUN apt-get update && export DEBIAN_FRONTEND=noninteractive \
#     && apt-get -y install --no-install-recommends <your-package-list-here>

# run dotnet workload update and install dotnet-ef
#USER vscode
RUN dotnet workload update && \
    dotnet tool install -g dotnet-ef

ENV PATH $PATH:/root/.dotnet/tools

#RUN /bin/bash --login -c "dotnet workload update && dotnet tool install --global dotnet-ef"

# export PATH="$HOME/.dotnet/tools:$PATH" to .bashrc
#RUN echo 'export PATH="$HOME/.dotnet/tools:$PATH"' >> /home/vscode/.bashrc