export default () => {
  return {
    files: ['**/*.test.ts', '!package/**/*'],
    watchMode: {
      ignoreChanges: ['tmp/**/*'],
    },
    extensions: ['ts'],
    workerThreads: false,
    nodeArguments: ['--import=tsx'],
  }
}
