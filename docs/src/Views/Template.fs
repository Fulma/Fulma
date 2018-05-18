module Template

let view =
    Render.contentFromMarkdown
        """
# Template

There is a **Fulma Minimal** template available, this is the quickest way to get started an *Elmish + Fulma* application from scratch.

## How to use ?

```shell
> dotnet new -i Fable.Template.Fulma.Minimal
> dotnet new fulma-minimal -n MyApp [-lang F#]
# Depending on your dotnet version, you may need the extra: [-lang F#]
# Please, look at the README.md file for instruction on how to use the template.
```

## Demo of the template

<center>
*Because my computer was really slow when recording, I made some cut in the GIF*
<br><br>
</center>

![Fulma minimal template demo](assets/fulma_minimal_demo.gif)

<center>
If you want to know more about this template you can take a look at the [README.md](https://github.com/MangelMaxime/Fulma/blob/master/templates/Content/README.md)
</center>
        """
