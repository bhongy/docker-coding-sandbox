## To start container

```sh
# use fsharpi
docker-compose run --rm dev
# use bash
docker-compose run --rm dev bash
```

## In the container

```bash
# use fsharp interactive
fsharpi

# compile to Program.exe
fsharpc Program.fs

# run Program.exe
mono Program.exe [...arguments]
```