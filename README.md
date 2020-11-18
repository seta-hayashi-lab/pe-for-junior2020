# ３回生プログラミング演習の課題用リポジトリ

## 使い方

### データのダウンロード

```
~ $ cd /自分の/作業したい/ディレクトリの/パス/
~ $ git clone https://github.com/seta-hayashi-lab/pe-for-junior2020.git
```


### 実装

#### 各自が自分の名前のブランチを切る

e.g. 油谷の場合

```
~ $ git checkout -b aburatani
```

#### 演習回のディレクトリ（１回目なら 1st/ 以下に自分の名前のディレクトリを作成し，その以下にプログラムを置く）

（マージしたときに以下のような形になるように）
```
- 1st
  |- aburatani
  |- ...
- 2nd
  |- aburatani
  |- ...
```

#### コミットしたらこの（リモート）リポジトリに，自分のブランチをPush

```
~ $ git remote add origin https://github.com/seta-hayashi-lab/pe-for-junior2020.git
~ $ git add .
~ $ git commit -m "任意のコミットメッセージ"
~ $ git push origin aburatani(<-ここは自分の名前のブランチ名)
```
