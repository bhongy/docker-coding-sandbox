## To start

```sh
# use OpenJDK for Java 8
docker-compose run --rm java8_dev 
```

You will be in the docker container with the isolated java environment.

https://code.visualstudio.com/docs/java/java-container

## Working with the compiler

```sh
# compile
javac MyClass.java

# run
java MyClass

# inspect the compiled class
javap -c MyClass.class
```

