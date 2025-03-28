class InterviewPrep {
    // Fundamentals.1: Scope, hoisting (var vs let/const)
    constructor() {
      this.exampleVar = "I'm hoisted (kind of)";
      let blockScoped = "I'm block-scoped (let/const)";
    }
  
    // Fundamentals.Closures
    closureExample() {
      const outerVar = "I'm closed over";
      return () => console.log(outerVar); // Inner function retains access
    }
  
    // Fundamentals.Prototypes
    // ES6 class syntax (prototype-based inheritance)
    static prototypeDemo() {
      class Parent {
        constructor(name) {
          this.name = name;
        }
      }
      class Child extends Parent {
        #privateField; // ES2022.PrivateFields
        constructor(name, age) {
          super(name);
          this.age = age;
          this.#privateField = 42;
        }
      }
      return new Child("Alice", 30);
    }
  
    // Fundamentals.thisBinding
    thisBindingDemo() {
      const obj = {
        value: "Hello",
        arrow: () => this, // Lexical 'this'
        regular() {
          return this; // Dynamic 'this'
        }
      };
      return { arrow: obj.arrow(), regular: obj.regular() };
    }
  
    // Fundamentals.EventLoop (macro vs microtasks)
    async eventLoopExample() {
      console.log("Start");
      setTimeout(() => console.log("Macrotask"), 0);
      Promise.resolve().then(() => console.log("Microtask"));
      await new Promise(res => res());
      console.log("End");
    }
  
    // ES6.ArrowFunctions
    arrowMethod = () => {
      return `Arrow functions don't rebind 'this' (value: ${this.exampleVar})`;
    };
  
    // ES6.Destructuring
    destructureExample({ name, age }) { // Parameter destructuring
      const arr = [1, 2, 3];
      const [first, ...rest] = arr; // Array destructuring
      return { first, rest, name };
    }
  
    // Async.3: Promise combinators
    static async promiseCombinators() {
      const promises = [Promise.resolve(1), Promise.reject("error")];
      const allSettled = await Promise.allSettled(promises); // ES2020
      const all = await Promise.all(promises).catch(e => e);
      return { allSettled, all };
    }
  
    // DataStructures.ArrayMethods
    arrayMethodsDemo() {
      return [1, 2, 3]
        .map(n => n * 2) // ES6
        .filter(n => n > 2)
        .flatMap(n => [n, n * 10]); // ES2019
    }
  
    // ES2020.OptionalChaining
    optionalChainingExample(obj) {
      return obj?.nested?.property ?? "default"; // ES2020.NullishCoalescing
    }
  
    // ES2022.TopLevelAwait (not in class method, but here's a workaround)
    static async topLevelAwaitDemo() {
      const data = await fetch('https://api.example.com');
      return data.json();
    }
  
    // ES2023.FindLast
    findLastDemo() {
      const arr = [1, 2, 3, 2];
      return arr.findLast(item => item === 2); // Returns last 2
    }
  
    // InterviewChallenges.Debouncing
    debounce(func, delay) {
      let timeoutId;
      return (...args) => {
        clearTimeout(timeoutId);
        timeoutId = setTimeout(() => func.apply(this, args), delay);
      };
    }
  
    // ES2023.ToReversed (non-mutating)
    nonMutatingMethods() {
      const arr = [1, 2, 3];
      return arr.toReversed(); // [3, 2, 1] (original array unchanged)
    }
  
    // Static block (ES2022.StaticBlocks)
    static {
      console.log("Class initialized (static block)");
    }
  }
  
  // Usage examples
  const demo = new InterviewPrep();
  console.log(demo.closureExample()()); // "I'm closed over"
  //console.log(InterviewPrep.prototypeDemo().#privateField); // SyntaxError (private field)
  console.log(demo.optionalChainingExample({})); // "default"
  console.log(demo.nonMutatingMethods()); // [3, 2, 1]