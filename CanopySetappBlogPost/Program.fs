module Program

open canopy
open canopy.classic
open canopy.runner.classic

[<EntryPoint>]
let main argv =
  //Parse all the args into the types that we use in the rest of the code
  let args = Args.parse argv

  configuration.chromeDir <- Common.executingDir()

  //Start the browser supplied in args
  start args.Browser

  //Register the tests that you want to run (under development, a specific page, all tests, etc)
  Tests.register (Some args.TestType)

  //Run tests
  run()

  System.Console.ReadKey() |> ignore
  //Quit all browsers
  quit ()

  //return code
  failedCount