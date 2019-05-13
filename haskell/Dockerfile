FROM haskell:8.6.3
WORKDIR /usr/app

COPY stack.yaml package.yaml ./

# -- use ghc in the container
# Install GHC.
# RUN stack setup && \
#   stack exec -- ghc --version

# Install dependencies.
RUN stack build --only-dependencies
COPY src src

EXPOSE 80
ENTRYPOINT [ "/bin/bash" ]
