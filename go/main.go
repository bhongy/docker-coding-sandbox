package main

import (
	"fmt"
	"log"
	"net/http"
)

type message struct {
	m string
}

func main() {
	// msg := message{m: "Hello World!"}
	// fmt.Println(msg.m)
	// log.Println(msg.m)

	http.HandleFunc("/", func(w http.ResponseWriter, r *http.Request) {
		fmt.Fprintf(w, "Hello from Docker")
	})

	fmt.Println("Listening on :8080")
	log.Fatal(http.ListenAndServe(":8080", nil))
}
