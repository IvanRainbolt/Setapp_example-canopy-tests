module Blog

open canopy.classic
open canopy.runner.classic
open Common

let underDevelopment () =
  "Search 'code review' article" &&& fun _ ->
    click ".hero-foot .search-toggle"
    "#main-search" << "code review"
    press enter
    ".post .entry-title a" == "Four valuable practices for a better code review"

  // test will fail beacuse context has defined before function in which program will go to blog.setapp.pl site. So it depend on result of previous test
  // test will work when you go to start page you want or you will adapt context (or before method)
  "Enter code review article - will not work" &&& fun _ ->
    click ".post .entry-title a[href='https://blog.setapp.pl/valuable-practices-better-code-review/'"
    on "https://blog.setapp.pl/valuable-practices-better-code-review/"

  // this test is independant so it will pass
  "Enter code review article - working" &&& fun _ ->
    !^ "https://blog.setapp.pl/?s=code+review"
    click ".post .entry-title a[href='https://blog.setapp.pl/valuable-practices-better-code-review/'"
    on "https://blog.setapp.pl/valuable-practices-better-code-review/"

let all() = 
  "Click 'Development tab'" &&& fun _ ->
    click ".hero-foot a[href='/category/development']"
    on "https://blog.setapp.pl/category/development/"
 
let run (testType: TestType option) =
  context "Blog tests"
  before(
    fun _ -> !^ "https://blog.setapp.pl/"
  )

  match testType with
    | Some UnderDevelopment -> underDevelopment()
    | Some All -> all()
    | _ -> ()