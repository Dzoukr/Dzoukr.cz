﻿module DzoukrCz.Client.SharedView

open Feliz
open Router

type prop
    with
        static member inline href (p:Page) = prop.href (p |> Page.toUrlSegments |> Router.formatPath)

type Html
    with
        static member inline a (text:string, p:Page) =
            Html.a [
                prop.href p
                prop.onClick Router.goToUrl
                prop.text text
            ]

        static member inline faIcon (cn:string) = Html.i [ prop.className cn ]
        static member inline faIconLink (cn:string) (href:string) =
            Html.a [
                prop.href href
                prop.children [ Html.faIcon cn ]
            ]
        static member inline divClassed (cn:string) (elms:seq<ReactElement>) = Html.div [ prop.className cn; prop.children elms ]
