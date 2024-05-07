[English](README.md) / [日本語](README.ja.md)
# Cubism Unity Samples Extended

Cubism Unity Samples Extended は [Live2D Cubism SDK for Unity] の使用例を示すサンプルプロジェクトです。

[Live2D Cubism SDK for Unity]: https://www.live2d.com/download/cubism-sdk/
[Live2D Cubism Editor]: https://www.live2d.com/


## ライセンス

[LICENSE.md](LICENSE.md) を参照してください。


## 開発環境

公開している Cubism SDK for Unity と同じ開発環境にて確認しています。

詳しくは、 [Cubism SDK for Unity](https://github.com/Live2D/CubismUnityComponents/blob/develop/README.ja.md#%E9%96%8B%E7%99%BA%E7%92%B0%E5%A2%83) を参照してください。

| Cubism SDK | Version |
| --- | --- |
| for Unity | 5-r.1 |


## 使用法

1. `./Assets` の下にあるすべてのファイルを、Unityプロジェクト内のLive2DCubismSDKがあるフォルダーにコピーしてください。
1. Unityプロジェクトの `./Assets/Live2D/Extends` の下にあるサンプルの中から、任意のシーンファイルを開いてください。
  - 各サンプルの詳細は[ディレクトリ構成](#ディレクトリ構成)、および[ドキュメント](#ドキュメント)を参照してください。


## ディレクトリ構成

Cubism Unity Samples Extended は、以下のようなディレクトリ構成になっております。

```
.
└─ Assets                           # サンプルのアセット
   └─ Live2D                
      └─ Cubism
         └─ Extends                 
            ├─ Blur                 # ブラーシェーダー
            ├─ Following            # メッシュに追従するオブジェクト
            ├─ FollowingCollider    # メッシュに追従するコライダー
            ├─ MaskLimit            # マスクの使用上限
            ├─ Mosaic               # モザイクシェーダー
            └─ SetTexture           # テクスチャの入れ替え
```


## ドキュメント

Cubism SDK マニュアルでは、プロジェクト中のサンプルについて詳しく解説を行っています。

[CubismUnitySamplesExtended](https://docs.live2d.com/cubism-sdk-manual/cubism-unity-samples-extended/)  
  └ [Blur](https://docs.live2d.com/cubism-sdk-manual/cubism-unity-samples-extended-blur/)  
  └ [Following](https://docs.live2d.com/cubism-sdk-manual/cubism-unity-samples-extended-following/)  
  └ [FollowingCollider](https://docs.live2d.com/cubism-sdk-manual/cubism-unity-samples-extended-following-collider/)  
  └ [MaskLimit](https://docs.live2d.com/cubism-sdk-manual/cubism-unity-samples-extended-mask-limit/)  
  └ [Mosaic](https://docs.live2d.com/cubism-sdk-manual/cubism-unity-samples-extended-mosaic/)  
  └ [SetTexture](https://docs.live2d.com/cubism-sdk-manual/cubism-unity-samples-extended-set-texture/)


## プロジェクトへの貢献

### フォークとプルリクエスト

修正、改善、さらには新機能をもたらすかどうかにかかわらず、プルリクエストに感謝します。メインリポジトリを可能な限りクリーンに保つために、必要に応じて個人用フォークと機能ブランチを作成してください。



## フォーラム

ご不明な点がございましたら、公式のLive2Dフォーラムに参加して、他のユーザーと話し合ってください。

- [Live2D 公式クリエイターズフォーラム](https://creatorsforum.live2d.com/)
- [Live2D Creators Forum(English)](https://community.live2d.com/)
