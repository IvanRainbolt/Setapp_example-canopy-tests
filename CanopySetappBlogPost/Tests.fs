module Tests

open Common

//The default argument passed from the console in the starter kit is UnderDevelopment
//This lets you simply comment/uncomment the test context/suite that you are working on
//As you add more tests for different pages, add an entry here
let underDevelopment () =
  Setapp.run(Some UnderDevelopment)
  Blog.run(Some UnderDevelopment)

//This is a list of all tests, which is useful when running in a CI environment where you want to
//As you add more tests for different pages, add an entry/entries here
let all =
  [
    All, Setapp.run
    All, Blog.run
  ]
  
//Code below does not need to be changed in most cases, it simply takes all of the tests and removes ones that dont
//meet the tags provided from arguments
let register testType =
  let exec predicate =
    all
    |> List.filter predicate
    |> List.iter (fun (_,func) -> func(testType))

  match testType with
  | (Some UnderDevelopment) -> underDevelopment()
  | (Some All)        -> exec (fun _ -> true)
  | (_) -> ()