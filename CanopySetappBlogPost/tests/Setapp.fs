module Setapp

open canopy.classic
open canopy.runner.classic
open Common

let underDevelopment () =
  "Join us button is enabled" &&& fun _ ->
    count "#join-us-cta" 1

  "Join us button redirect to Career page" &&& fun _ ->
    displayed ".cta .button#join-us-cta"
    click (".button#join-us-cta") 
    on "https://setapp.pl/career"


let all() = 
  "Join us button is present" &&& fun _ ->
    displayed ".button#join-us-cta"

  "Random button is not present" &&& fun _ ->
    notDisplayed ".button#random-button"

  "Join us button is enabled" &&& fun _ ->
    enabled ".button#join-us-cta"

  "What we do has 3 boxes" &&& fun _ ->
    count ".landing-what-we-do .images .landing-what-we-do-box" 3

 
let run (testType: TestType option) =
  context "Setapp page tests"
  once(
    fun _ -> !^ "https://setapp.pl"
  )

  match testType with
    | Some UnderDevelopment -> underDevelopment()
    | Some All -> all()
    | _ -> ()