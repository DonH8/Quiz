const readline = require('readline');
const Options = require('./Options');
const Questions = require('./Questions');
const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout
});
let totalTimeInSeconds = 40;
let countCorrect = 0;
class Program {
  constructor(questions, options) {
    this.questions = questions;
    this.options = options;
  }
  async quizi() {
    let countf = 0;
    let countv = 0;
    const isQuestionPrinted = new Array(this.questions.length).fill(false);
    let i = 0;
    const processQuestion = () => {
      if (!isQuestionPrinted[i]) {
        console.log(
          this.questions[i].getQuestion() +
            "\n" +
            this.options[i].writeOptions() +
            "\n" +
            this.questions[i].getHint() +
            "\n"
        );
        isQuestionPrinted[i] = true;
      }
    };
    const processAnswer = (answer) => {
      processQuestion();

      if (answer !== "A" && answer !== "B" && answer !== "C" && answer !== "D" && answer !== "fiftyfifty" && answer !== "publiku" &&answer !== "exit" && answer!=="shfaq") {
        console.log("\n" +"Input invalid mund te shenoni vetem: A, B, C, D, fiftyfifty, publiku, exit, shfaq" +"\n");
        isQuestionPrinted[i] = !isQuestionPrinted[i];
        i--;
      } else if (answer === "shfaq") {
        isQuestionPrinted[i] = !isQuestionPrinted[i];
        i--;
      } else if (answer === "exit") {
        console.log("Numri i pergjigjjeve te sakta " + countCorrect);
        process.exit(0);
      } else if (answer === "fiftyfifty" && countf === 0) {
        fifty(this.questions[i], this.options[i]);
        countf++;
        i--;
      } else if (answer === "fiftyfifty" && countf > 0) {
        console.log("\n" + "Nuk e keni me opcionin 50/50" + "\n");
        isQuestionPrinted[i] = !isQuestionPrinted[i];
        i--;
      } else if (answer === "publiku" && countv === 0) {
        Vote(this.questions[i], this.options[i]);
        countv++;
        i--;
      } else if (answer === "publiku" && countv > 0) {
        console.log("\n" + "Nuk e keni me opcionin e publikut" + "\n");
        isQuestionPrinted[i] = !isQuestionPrinted[i];
        i--;
      } else if (answer === this.questions[i].getCorrectAnswer()) {
        countCorrect++;
        console.log("\n" + "Pergjigjja e sakte" + "\n");
      } else {
        console.log("\n" + "Pergjigjja jo e sakte" + "\n");
      }
      i++;
      if (i < this.questions.length) {
        rl.question("", processAnswer);
      } else {
        // Stop the timer if all questions are answered
        stopTimer();
        console.log("\n" +"Numri i pergjigjjeve te sakta: " + countCorrect);
        process.exit(0);
      }
    };

    processQuestion();
    rl.question("", processAnswer);

    // Start the timer
    startTimer();
  }
}

function startTimer() {
  timer = setTimeout(() => {
    console.log(
      "\n" +
      "Koha juaj ka mbaruar." +
      "\n" +
      "Numri i pergjigjjeve te sakta: " +
      countCorrect
    );
    setTimeout(() => {
      process.exit(0);
    }, 2000);
  }, totalTimeInSeconds * 1000);
}

function stopTimer() {
  clearTimeout(timer);
}
function fifty(questions, options) {
    const rInt = Math.floor(Math.random() * 3) + 1;
  
    if (questions.getCorrectAnswer() === "A") {
      if (rInt === 1) {
        console.log("\n" + "50/50 ka shfaqur:" + "\n" + options.getOptionA() + " " + options.getOptionB() + "\n");
      } else if (rInt === 2) {
        console.log("\n" + "50/50 ka shfaqur:" + "\n" + options.getOptionA() + "\n" + options.getOptionC() + "\n");
      } else {
        console.log("\n" + "50/50 ka shfaqur:" + "\n" + options.getOptionA() + "\n" + "     " + options.getOptionD() + "\n");
      }
    } else if (questions.getCorrectAnswer() === "B") {
      if (rInt === 1) {
        console.log("\n" + "50/50 ka shfaqur:" + "\n" + options.getOptionA() + " " + options.getOptionB() + "\n");
      } else if (rInt === 2) {
        console.log("\n" + "50/50 ka shfaqur:" + "\n" + "     " + options.getOptionB() + "\n" + options.getOptionC() + "\n");
      } else {
        console.log("\n" + "50/50 ka shfaqur:" + "\n" + "     " + options.getOptionB() + "\n" + "     " + options.getOptionD() + "\n");
      }
    } else if (questions.getCorrectAnswer() === "C") {
      if (rInt === 1) {
        console.log("\n" + "50/50 ka shfaqur:" + "\n" + options.getOptionA() + "\n" + options.getOptionC() + "\n");
      } else if (rInt === 2) {
        console.log("\n" + "50/50 ka shfaqur:" + "\n" + "     " + options.getOptionB() + "\n" + options.getOptionC() + "\n");
      } else {
        console.log("\n" + "50/50 ka shfaqur:" + "\n" + options.getOptionC() + " " + options.getOptionD() + "\n");
      }
    } else {
      if (rInt === 1) {
        console.log("\n" + "50/50 ka shfaqur:" + "\n" + options.getOptionA() + "\n" + "     " + options.getOptionD() + "\n");
      } else if (rInt === 2) {
        console.log("\n" + "50/50 ka shfaqur:" + "\n" + "     " + options.getOptionB() + "\n" + "     " + options.getOptionD() + "\n");
      } else {
        console.log("\n" + "50/50 ka shfaqur:" + "\n" + options.getOptionC() + " " + options.getOptionD() + "\n");
      }
    }
  }
function Vote(questions, options) {
    const rInt = Math.floor(Math.random() * 3) + 1;
    const correct = Math.floor(Math.random() * (91 - 50 + 1)) + 50;
    const wrong1 = Math.floor(Math.random() * (100 - correct));
    const wrong2 = Math.floor(Math.random() * (100 - correct - wrong1));
    const wrong3 = 100 - correct - wrong1 - wrong2;
  
    if (questions.getCorrectAnswer() === "A") {
      if (rInt === 1) {
        console.log("\n" + "Votat e publikut jane: " + "\n" + "A: " + correct + "%" + " B: " + wrong1 + "%" + "\n" + "C: " + wrong2 + "%" + " D: " + wrong3 + "%" + "\n");
      } else if (rInt === 2) {
        console.log("\n" + "Votat e publikut jane: " + "\n" + "A: " + correct + "%" + " B: " + wrong3 + "%" + "\n" + "C: " + wrong1 + "%" + " D: " + wrong2 + "%" + "\n");
      } else {
        console.log("\n" + "Votat e publikut jane: " + "\n" + "A: " + correct + "%" + " B: " + wrong2 + "%" + "\n" + "C: " + wrong3 + "%" + " D: " + wrong1 + "%" + "\n");
      }
    } else if (questions.getCorrectAnswer() === "B") {
      if (rInt === 1) {
        console.log("\n" + "Votat e publikut jane: " + "\n" + "A: " + wrong1 + "%" + " B: " + correct + "%" + "\n" + "C: " + wrong2 + "%" + " D: " + wrong3 + "%" + "\n");
      } else if (rInt === 2) {
        console.log("\n" + "Votat e publikut jane: " + "\n" + "A: " + wrong3 + "%" + " B: " + correct + "%" + "\n" + "C: " + wrong1 + "%" + " D: " + wrong2 + "%" + "\n");
      } else {
        console.log("\n" + "Votat e publikut jane: " + "\n" + "A: " + wrong2 + "%" + " B: " + correct + "%" + "\n" + "C: " + wrong3 + "%" + " D: " + wrong1 + "%" + "\n");
      }
    } else if (questions.getCorrectAnswer() === "C") {
      if (rInt === 1) {
        console.log("\n" + "Votat e publikut jane: " + "\n" + "A: " + wrong1 + "%" + " B: " + wrong2 + "%" + "\n" + "C: " + correct + "%" + " D: " + wrong3 + "%" + "\n");
      } else if (rInt === 2) {
        console.log("\n" + "Votat e publikut jane: " + "\n" + "A: " + wrong2 + "%" + " B: " + wrong3 + "%" + "\n" + "C: " + correct + "%" + " D: " + wrong1 + "%" + "\n");
      } else {
        console.log("\n" + "Votat e publikut jane: " + "\n" + "A: " + wrong3 + "%" + " B: " + wrong1 + "%" + "\n" + "C: " + correct + "%" + " D: " + wrong2 + "%" + "\n");
      }
    } else {
      if (rInt === 1) {
        console.log("\n" + "Votat e publikut jane: " + "\n" + "A: " + wrong2 + "%" + " B: " + wrong1 + "%" + "\n" + "C: " + wrong3 + "%" + " D: " + correct + "%" + "\n");
      } else if (rInt === 2) {
        console.log("\n" + "Votat e publikut jane: " + "\n" + "A: " + wrong1 + "%" + " B: " + wrong3 + "%" + "\n" + "C: " + wrong2 + "%" + " D: " + correct + "%" + "\n");
      } else {
        console.log("\n" + "Votat e publikut jane: " + "\n" + "A: " + wrong3 + "%" + " B: " + wrong2 + "%" + "\n" + "C: " + wrong1 + "%" + " D: " + correct + "%" + "\n");
      }
    }
  }

// Create instances of Questions and Options and pass them to the Program constructor
const optionsquizi1 = [
    new Options("A:Don", "B:Don", "C:Don", "D:Don"),
    new Options("A:Don1", "B:Don1", "C:Don1", "D:Don1"),
    new Options("A:Don2", "B:Don2", "C:Don2", "D:Don2"),
    new Options("A:Don3", "B:Don3", "C:Don3", "D:Don3")
  ];
  
const questionquizi1 = [
    new Questions("Test 1", optionsquizi1[0], "E sakte nen C", "C"),
    new Questions("Test 2", optionsquizi1[1], "E sakte nen D", "D"),
    new Questions("Test 3", optionsquizi1[2], "E sakte nen B", "B"),
    new Questions("Test 4", optionsquizi1[3], "E sakte nen A", "A")
  ];
  
const kuizi = new Program(questionquizi1, optionsquizi1);
kuizi.quizi();