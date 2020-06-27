function solve() {

   const author = document.getElementById('creator');
   const title = document.getElementById('title');
   const category = document.getElementById('category');
   const content = document.getElementById('content');
   const createBtn = document.getElementsByTagName('button')[0];
   const articleSection = document.querySelector('.site-content section');
   const archiveUl = document.querySelector('.archive-section ul');

   createBtn.addEventListener('click', function (e) {
      e.preventDefault();

      const article = document.createElement('article');
      const heading1 = document.createElement('h1');
      const categoryParagraph = document.createElement('p');
      const categoryStrong = document.createElement('strong');
      const creatorParagraph = document.createElement('p');
      const creatorStrong = document.createElement('strong');
      const contentParagraph = document.createElement('p');
      const buttonsDiv = document.createElement('div');
      const deleteBtn = document.createElement('button');
      const archiveBtn = document.createElement('button');

      heading1.textContent = title.value.trim();
      article.appendChild(heading1);

      categoryParagraph.textContent = `Category:`;
      categoryStrong.textContent = category.value.trim();
      categoryParagraph.appendChild(categoryStrong);
      article.appendChild(categoryParagraph);

      creatorParagraph.textContent = `Creator:`;
      creatorStrong.textContent = author.value.trim();
      creatorParagraph.appendChild(creatorStrong);
      article.appendChild(creatorParagraph);

      contentParagraph.textContent = content.value.trim();
      article.appendChild(contentParagraph);

      buttonsDiv.classList.add('buttons');
      deleteBtn.classList.add('btn');
      deleteBtn.classList.add('delete');
      archiveBtn.classList.add('btn');
      archiveBtn.classList.add('archive');
      deleteBtn.textContent = 'Delete';
      archiveBtn.textContent = 'Archive';
      buttonsDiv.appendChild(deleteBtn);
      buttonsDiv.appendChild(archiveBtn);
      article.appendChild(buttonsDiv);

      articleSection.appendChild(article);

      document.getElementById('creator').value = '';
      document.getElementById('title').value = '';
      document.getElementById('category').value = '';
      document.getElementById('content').value = '';

      deleteBtn.addEventListener('click', function (e) {

         article.remove();
      });

      archiveBtn.addEventListener('click', function (e) {

         const listItem = document.createElement('li');

         listItem.textContent = heading1.textContent;
         article.remove();

         archiveUl.appendChild(listItem);
         let listItems = [...document.querySelectorAll('.archive-section ul > li')];

         archiveUl.innerHTML = '';
         
         listItems.sort((a, b) => {

            let first = a.textContent.toUpperCase();
            let second = b.textContent.toUpperCase();

            return first.localeCompare(second);
         });

         for (let i = 0; i < listItems.length; i++) {

            archiveUl.appendChild(listItems[i]);
         }

      });
   });

}
