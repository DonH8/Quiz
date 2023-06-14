class Options {
  constructor(OptionA, OptionB, OptionC, OptionD) {
    this.OptionA = OptionA;
    this.OptionB = OptionB;
    this.OptionC = OptionC;
    this.OptionD = OptionD;
  }

  writeOptions() {
    const writeOptions = `${this.OptionA} ${this.OptionB}\n${this.OptionC} ${this.OptionD}`;
    return writeOptions;
  }

  getOptionA() {
    return this.OptionA;
  }

  getOptionB() {
    return this.OptionB;
  }

  getOptionC() {
    return this.OptionC;
  }

  getOptionD() {
    return this.OptionD;
  }
}

module.exports = Options;
