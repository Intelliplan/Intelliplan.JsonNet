﻿module Intelliplan.JsonNet.Tests.Serialisation

open Fuchu

open Intelliplan.JsonNet

type HelloWorld =
  | HelloWorld of string * int

[<Tests>]
let tests =
  testList "can serialise normally" [
    testCase "simple string" <| fun _ ->
      Serialisation.serialise' "hi" |> ignore

    testCase "simple sum type" <| fun _ ->
      let sample = HelloWorld ("hi", 12345)
      let name, data =
        Serialisation.serialise' sample

      Assert.Equal("should have data", true, data.Length > 0)

      let o = Serialisation.deserialise' (typeof<HelloWorld>, data) :?> HelloWorld
      Assert.Equal("should eq structurally", sample, o)
    ]