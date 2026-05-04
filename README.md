# pew_wing

Permainan Asteroid menggunakan Game Engine Unity<br><hr>

# Pengembang<br>
Daffa Ahmad Farhan (3337240034)<br>
Altaf Hafeesa Imtiaz (3337240054)<br>
Faishal Danni (3337240072)<br>

# Aplikasi yang Diperlukan

1. Unity Hub dan Unity Editor 2022.3.62f3
2. Git
3. Git LFS
4. Github Desktop (Memepermudah Version Control)

# Cara Instalasi Proyek
Ikuti langkah-langkah berikut untuk menghindari kendala saat setup proyek:
1. Clone proyek ini<br>
Melalui Github Desktop: (File->Clone repository->URL)<br>
Atau melalui terminal:
```
git clone https://github.com/FaishalDanni-24/pew_wing.git
```
2. Install git-lfs https://git-lfs.com/ dan jalankan perintah ini di command-prompt minimal sekali setelah install aplikasi git-lfs.
```
git lfs install
```
3. Masuk ke folder proyek dan jalankan command ini untuk mengambil data aset
```
git lfs pull
```
4. Buka project di Unity Hub dan pastikan versi Unity yang digunakan sama seperti yang ditulis di atas (Unity Editor 2022.3.62f3)
5. Menunggu unity generate file, import packages, dan compile shaders dan skrip yang diperlukan projek (Proses ini cukup lama dan hanya terjadi sekali saat proyek pertama dibuka)

# Cara Kontribusi
Ikuti tahap ini untuk berkontribusi:
1. Sebelum bekerja, ambil perubahan terbaru dari repository<br>
Melalui Github Desktop: (Fetch origin -> Pull origin)
Melalui Terminal:
```
git pull
```
2. Buat Branch dan Hindari Modifikasi ke main
Melalui Github desktop: (Current branch -> New Branch)
Melalui Terminal:
```
git checkout -b nama_branch
```
Sesuaikan nama_branch dengan yang dikerjakan
3. Hindari mengubah dan mengerjakan file yang sama, Gunakan Prefab, Commit setiap ada perubahan di proyek
4. Jika sudah mengerjakan, maka cara untuk commit
Melalui Github Desktop: (Pilih File yang Diubah -> Isi Summary dan Description -> Pencet Commit files to branch)
Melalui Terminal:
```
git add .
git commit -m "Menambahkan fitur movement asteroid"
```
Ubah . sesuai file yang diubah (Jika mau file tertentu yang dicommit) dan tulis summary dan description sesuai yang sudah dikerjakan
5. Push Branch
Melalui GitHub Desktop: (Push origin)
atau terminal:
```
git push origin nama_branch
```
6. Buat PR ke main (Buka Repo Github -> Pencet Pull Request atau Compare & pull request -> Buat isi PR dan Pilih FaishalDanni-24 untuk request sebagai Reviewer -> Tunggu informasi/instruksi lanjut dari reviewer)

7. Pull Request akan diterima dan dimerge ke main jika sudah dicek dan tidak ada konflik

# Catatan Proyek
1. Pastikan Unity yang digunakan sesuai dengan yang tertulis
2. Git LFS wajib diinstal, dan run command git lfs install minimal sekali
3. Git LFS digunakan untuk file data besar (Biasanya aset seperti Sprite, Music, Model, dll)
4. Branch main hanya untuk fitur yang sudah dipastikan dapat bekerja tanpa error/bug, buat branch jika sedang membuat fitur
5. Jika ada yang kurang, silahkan hubungi owner repo
