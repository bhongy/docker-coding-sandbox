// from a talk by Venkat Subramaniam: https://www.youtube.com/watch?v=1OpAgZvYXLQ
import java.util.*;
import java.util.function.Consumer;

public class LambdaExample {
  public static void main(String[] args) {
    // thread();
    iterate();
  }

  private static void thread() {
    // Thread thread = new Thread(new Runnable() {
    //   public void run() {
    //     System.out.println("In another thread"); 
    //   }
    // });
    Thread thread = new Thread(() -> System.out.println("In another thread"));
    thread.start();
    
    System.out.println("In main");
  }

  private static void iterate() {
    List<Integer> numbers = Arrays.asList(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
    
    // for (int i = 0; i < numbers.size(); i++) {
    //   System.out.println(numbers.get(i));
    // }

    // for (int n : numbers) {
    //   System.out.println(n);
    // }

    // polymorphism, declare what we want numbers to do -> ask it to iterate
    // "how" it iterates we don't know and don't care 
    // numbers.forEach(/* ... */);

    // numbers.forEach(new Consumer<Integer>() {
    //   public void accept(Integer value) {
    //     System.out.println(value);
    //   }
    // });

    // numbers.forEach(value -> System.out.println(value));
    numbers.forEach(System.out::println); // `::` is method reference syntax

    // int total = numbers.stream().reduce(0, (prev, v) -> prev + v);
    int total = numbers.stream().reduce(0, Integer::sum);
    System.out.println("total: " + total);

    // instance method works as well
    String concatenated = numbers.stream()
      .map(String::valueOf) // static method reference
      // .reduce("", (prev, v) -> prev.concat(v));
      /* to be honest though, I'd rather be explicit using the version above */
      .reduce("", String::concat); // instance method reference
    System.out.println(concatenated);

    // int sumDoubleEven = 0;
    // for (int num : numbers) {
    //   if (num % 2 == 0) {
    //     sumDoubleEven += num * 2;
    //   }
    // }

    int sumDoubleEven = numbers.stream()
      .filter(num -> num % 2 == 0)
      .map(num -> num * 2).sum();
      //.reduce(0, Integer::sum);
      // .mapToInt(num -> num * 2)
      // .sum();
    System.out.println("sum double even: " + sumDoubleEven);
  }
}
