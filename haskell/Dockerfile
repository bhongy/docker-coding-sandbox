# limit by haskell-ide-engine@50cb42fb3df (v0.9.0.0) requires 8.6.2
FROM haskell:8.6.2

WORKDIR /usr
# libs needed for hie for debian
RUN apt-get update && \
    apt-get install -y libicu-dev libtinfo-dev libgmp-dev && \
    # hie needs stack 1.9.3 - haskell:8.6.2 comes with stack 1.9.1
    stack upgrade
COPY haskell-ide-engine-6254c09f.zip ./
RUN git clone https://github.com/haskell/haskell-ide-engine.git --recurse-submodules && \
    cd haskell-ide-engine && \
    git checkout 6254c09f && \
    ./install.hs hie-8.6.2 && \
    ./install.hs build-doc
# clean up apt-get
RUN apt-get autoremove -y \
    && apt-get clean -y \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /usr/app
COPY stack.yaml package.yaml ./
# -- use ghc in the container
# Install GHC.
# RUN stack setup && \
#   stack exec -- ghc --version
# Install dependencies.
RUN stack build --only-dependencies

EXPOSE 80
ENTRYPOINT [ "/bin/bash" ]
