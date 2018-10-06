# from: https://vinta.ws/code/remotely-debug-a-python-app-inside-a-docker-container-in-visual-studio-code.html

FROM python:3.6.6-alpine3.7 AS builder

WORKDIR /usr/src/app/

RUN apk add --no-cache --virtual .build-deps \
    build-base \
    openjpeg-dev \
    openssl-dev \
    zlib-dev

COPY requirements.txt .
RUN pip install --user -r requirements.txt

FROM python:3.6.6-alpine3.7 AS runner

ENV PATH=$PATH:/root/.local/bin
ENV FLASK_APP=app.py

WORKDIR /usr/src/app/

RUN apk add --no-cache --virtual .run-deps \
    openjpeg \
    openssl

EXPOSE 8000/tcp

# copy from "builder" stage - this stage will not contain any apk add .build-deps
COPY --from=builder /root/.local/ /root/.local/
COPY . .

CMD ["flask", "run"]