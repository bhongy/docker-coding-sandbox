package main

import (
	"fmt"
	"log"
)

type message struct {
	m string
}

func main() {
	msg := message{m: "Hello World!"}
	fmt.Println(msg.m)
	log.Println(msg.m)
}
