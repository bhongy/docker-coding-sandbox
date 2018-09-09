// @flow

class Failure<T: string> {
  static of(message: T): Failure<T> {
    // "lift" type as an array of _one_ string so we can "concatenate" them later
    const messages = [message];
    return new Failure(messages);
  }

  static concat(a: Failure<T>, b: Failure<T>): Failure<T> {
    const messages = a.messages.concat(b.messages);
    return new Failure(messages);
  }

  static get identity() {
    return new Failure([]);
  }

  messages: Array<T>;
  constructor(messages: Array<T>): void {
    this.messages = messages;
  }
}

type Result<T, F> = T | Failure<F>;

// --- usage

// type FailureMessage = string;
type FailureMessage = 'string contains bad word' | 'string is too long';

const validateBadWord = (badword: string) => (
  input: string
): Result<null, FailureMessage> => {
  if (input.includes(badword)) {
    // return Failure.of('foo bar'); // fail incorrect failure message
    return Failure.of('string contains bad word');
  }
  return null;
};

const validateLength = (maxLength: number) => (
  input: string
): Result<null, FailureMessage> => {
  if (input.length > maxLength) {
    return Failure.of('string is too long');
  }
  return null;
};

type R = Result<null, FailureMessage>;
function concatValidationResults(r1: R, r2: R): R {
  // because javascript lacks pattern matching
  if (r1 === null && r2 === null) {
    return null;
  } else if (r1 instanceof Failure && r2 === null) {
    return r1;
  } else if (r1 === null && r2 instanceof Failure) {
    return r2;
  } else if (r1 instanceof Failure && r2 instanceof Failure) {
    return Failure.concat(r1, r2);
  }
  // because javascript sucks - let's all write Haskell or F#
  throw Error('Should never reached.');
}

const validateBulk = (input: string): Result<null, FailureMessage> =>
  [validateLength(10), validateBadWord('monad'), validateBadWord('?!?!')]
    .map(validation => validation(input))
    .reduce(concatValidationResults, Failure.identity);

console.log(validateBulk('moo'));
console.log(validateBulk('monad'));
console.log(validateBulk('text that is very long ?!?!'));
