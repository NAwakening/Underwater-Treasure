Shader"Custom/Stencil"
{
    Properties
    {
        [IntRange] _StencilID ("Stencil ID", Range(0,255)) = 0
    }
    SubShader{
        Tags{
            "RenderType" = "Opaque"
            "Queue" = "Geometry"
            "RenderPipeline" = "UniversalPipelin"
        } 
        Pass{ //Configuracio de Renderizacion
            Blend Zero One //El objeto hace que sea invisible
            ZWrite Off // No bloqueaer objeto detras de el

            Stencil
            {
                Ref [_StencilID]
                Comp Always
                Pass Replace
                Fail keep
            }
        }
    }
}
