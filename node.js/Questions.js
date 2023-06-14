class Questions {
    constructor(question, options, hint, correctAnswer) {
      this.question = question;
      this.options = options;
      this.correctAnswer = correctAnswer;
      this.hint = hint;
    }
  
    getCorrectAnswer() {
      return this.correctAnswer;
    }
  
    getQuestion() {
      return this.question;
    }
  
    getHint() {
      return `( ${this.hint} )`;
    }
  }
  
  module.exports = Questions;
  const Options = require('./Options');